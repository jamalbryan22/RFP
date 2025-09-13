import { ReactNode } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";
import { jwtDecode } from "jwt-decode";
import { JwtPayload } from "../../types/JwtPayload";

export default function MainLayout({ children }: { children: ReactNode }) {
  const { setToken } = useAuth();
  const navigate = useNavigate();
  const { userId } = useAuth();

  const handleSignOut = () => {
    setToken(null);
    navigate("/");
  };

  const token = localStorage.getItem("token");
  if (token) {
    const decoded = jwtDecode<JwtPayload>(token);
    const userId =
      decoded[
        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
      ];
    console.log(userId);
  }

  return (
    <div className="min-h-dvh flex flex-col">
      <header className="fixed inset-x-0 top-0 z-50 bg-[var(--color-surface)] border-b shadow-sm">
        <div className="container h-14 flex items-center justify-between">
          <Link to="/" className="font-semibold">
            RFP Portal
          </Link>
          <nav className="flex gap-4 text-sm">
            <Link to="/post-request" className="hover:text-[--color-primary]">
              Post Request
            </Link>
            <Link
              to="/search-requests"
              className="hover:text-[--color-primary]"
            >
              Search Requests
            </Link>
            <Link
              to="/my-service-requests"
              className="hover:text-[--color-primary]"
            >
              My Request
            </Link>
            <Link
              to="/manage-proposals"
              className="hover:text-[--color-primary]"
            >
              Manage Proposals
            </Link>
            <Link to="/messages" className="hover:text-[--color-primary]">
              Messages
            </Link>
            <Link
              to={`/profile/${userId}`}
              className="hover:text-[--color-primary]"
            >
              Profile
            </Link>
            <Link to="/admin" className="hover:text-[--color-primary]">
              Admin Dashboard
            </Link>
            {userId && (
              <button
                className="signout-button hover:text-[--color-primary]"
                onClick={handleSignOut}
              >
                Sign Out
              </button>
            )}
          </nav>
        </div>
      </header>

      <main className="flex-1 pt-14">
        <div className="container py-6">{children}</div>
      </main>

      <footer className="border-t bg-[var(--color-surface)]">
        <div className="container py-4 text-sm text-slate-500">
          © {new Date().getFullYear()} RFP Portal
        </div>
      </footer>
    </div>
  );
}
