import { Routes, Route } from "react-router-dom";
import PrivateRoute from "./routes/PrivateRoute";
import "@fortawesome/fontawesome-free/css/all.min.css";
import LoginPage from "./features/auth/LoginPage.tsx";
import DashboardPage from "./features/dashboard/DashboardPage.tsx";
import PostRequestPage from "./features/requests/PostRequestPage.tsx";
import MyServiceRequest from "./features/requests/MyServiceRequest.tsx";
import ManageRequest from "./features/requests/ManageRequest.tsx";
import SearchRequestsPage from "./features/requests/SearchRequestsPage.tsx";
import PostProposalPage from "./features/proposals/PostProposalPage.tsx";
import ManageProposalsPage from "./features/proposals/ManageProposalsPage.tsx";
import MessagesPage from "./features/messages/MessagesPage.tsx";
import UserProfilePage from "./features/profile/UserProfilePage.tsx";
import AdminDashboardPage from "./features/admin/AdminDashboardPage.tsx";
import ServiceRequestDetailPage from "./features/requests/ServiceRequestDetailPage.tsx";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import MainLayout from "./components/layout/MainLayout";

function App() {
  return (
    <>
      <MainLayout>
        <ToastContainer position="top-center" autoClose={3000} />

        <Routes>
          {/* Public Route */}
          <Route path="/" element={<DashboardPage />} />
          <Route path="/login" element={<LoginPage />} />
          {/* Protected Routes */}
          <Route element={<PrivateRoute />}>
            <Route path="/dashboard" element={<DashboardPage />} />
            <Route path="/post-request" element={<PostRequestPage />} />
            <Route path="/search-requests" element={<SearchRequestsPage />} />
            <Route
              path="/service-requests/:id"
              element={<ServiceRequestDetailPage />}
            />
            <Route path="/my-service-requests" element={<MyServiceRequest />} />
            <Route path="/manage-request" element={<ManageRequest />} />
            <Route path="/post-proposal" element={<PostProposalPage />} />
            <Route path="/manage-proposals" element={<ManageProposalsPage />} />
            <Route path="/messages" element={<MessagesPage />} />
            <Route path="/profile/:id" element={<UserProfilePage />} />
            <Route path="/admin" element={<AdminDashboardPage />} />
          </Route>
          {/* Catch all */}
          <Route path="*" element={<div>404 Not Found</div>} />
        </Routes>
      </MainLayout>
    </>
  );
}

export default App;
