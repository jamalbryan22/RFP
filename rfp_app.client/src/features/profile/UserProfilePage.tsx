import { useEffect, useMemo, useState } from "react";
import { useParams } from "react-router-dom";
import api from "../../api/axios";
import { UserProfileDto } from "../../types/User";

export default function UserProfilePage() {
  const { id } = useParams();
  const [user, setUser] = useState<UserProfileDto | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    let cancelled = false;
    setLoading(true);
    api
      .get(`/applicationuser/profile/${id}`)
      .then((res) => {
        if (!cancelled) setUser(res.data);
      })
      .finally(() => {
        if (!cancelled) setLoading(false);
      });
    return () => {
      cancelled = true;
    };
  }, [id]);

  const avgRating = useMemo(() => {
    if (!user) return null;
    const n = user.numberOfCompletedServiceRequest || 0;
    if (n <= 0) return null;
    const val = user.rating / n;
    // clamp to 0–5 for safety
    return Math.max(0, Math.min(5, Number(val.toFixed(1))));
  }, [user]);

  if (loading) {
    return (
      <div className="container mx-auto max-w-2xl px-4 py-8">
        <div className="rounded-xl border bg-white p-6 shadow-sm">
          <div className="flex flex-col items-center text-center">
            <div className="mb-4 size-36 animate-pulse rounded-full bg-slate-200" />
            <div className="mb-2 h-6 w-48 animate-pulse rounded bg-slate-200" />
            <div className="mb-1 h-4 w-64 animate-pulse rounded bg-slate-200" />
            <div className="mt-4 grid w-full grid-cols-2 gap-3">
              <div className="h-10 rounded bg-slate-200" />
              <div className="h-10 rounded bg-slate-200" />
            </div>
          </div>
        </div>
      </div>
    );
  }

  if (!user)
    return <div className="container mx-auto px-4 py-8">Not found.</div>;

  return (
    <div className="container mx-auto max-w-2xl px-4 py-8">
      <div className="rounded-xl border bg-white p-6 shadow-sm">
        <div className="flex flex-col items-center text-center">
          <img
            src={user.profilePictureUrl || "/profile-placeholder.png"}
            alt="Profile"
            className="mb-4 size-36 rounded-full border-2 border-slate-300 object-cover"
            onError={(e) => {
              (e.currentTarget as HTMLImageElement).src =
                "/profile-placeholder.png";
            }}
          />

          <h2 className="text-2xl font-semibold">
            {user.firstName} {user.lastName}
          </h2>

          <p className="mt-1 text-slate-600">
            {user.city}, {user.state}, {user.country}
          </p>

          {user.bio && (
            <p className="mt-4 max-w-prose text-slate-700">{user.bio}</p>
          )}

          <div className="mt-6 grid w-full grid-cols-2 gap-3 sm:max-w-md">
            <div className="rounded-lg border bg-slate-50 px-4 py-3">
              <div className="text-xs uppercase text-slate-500">Rating</div>
              <div className="text-lg font-semibold">
                {avgRating !== null ? `${avgRating} / 5` : "—"}
              </div>
            </div>
            <div className="rounded-lg border bg-slate-50 px-4 py-3">
              <div className="text-xs uppercase text-slate-500">
                Completed Request
              </div>
              <div className="text-lg font-semibold">
                {user.numberOfCompletedServiceRequest}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
