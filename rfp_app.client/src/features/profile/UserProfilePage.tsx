import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import api from "../../api/axios";
import "./UserProfilePage.css";
import { UserProfileDto } from "../../types/User";

const UserProfilePage = () => {
  const { id } = useParams();
  const [user, setUser] = useState<UserProfileDto | null>(null);

  useEffect(() => {
    api.get(`/applicationuser/profile/${id}`).then((res) => setUser(res.data));
    console.log(`User Profile information: ${JSON.stringify(user)}`);
  }, [id]);

  if (!user) return <div>Loading...</div>;
  console.log(`User Profile information: ${JSON.stringify(user)}`);

  return (
    <div className="user-profile">
      <img src={user.profilePictureUrl} alt="Profile" />
      <h2>
        {user.firstName} {user.lastName}
      </h2>
      <p>{user.bio}</p>
      <p>
        Location: {user.city}, {user.state}, {user.country}
      </p>
      <p>Rating: {user.rating / user.numberOfCompletedServiceRequest} / 5</p>
      <p>Completed Projects: {user.numberOfCompletedServiceRequest}</p>
    </div>
  );
};

export default UserProfilePage;
