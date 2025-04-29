import { Routes, Route } from 'react-router-dom';
import NavBar from './components/NavBar/NavBar';

// Import your page components (stub them if not built yet)
import DashboardPage from './features/dashboard/DashboardPage.tsx'; 
import PostRequestPage from './features/requests/PostRequestPage.tsx';
import SearchRequestsPage from './features/requests/SearchRequestsPage.tsx';
import PostProposalPage from './features/proposals/PostProposalPage.tsx';
import ManageProposalsPage from './features/requests/ManageProposalsPage.tsx';
import MessagesPage from './features/messages/MessagesPage.tsx';
import ProfilePage from './features/profile/ProfilePage.tsx';
import AdminDashboardPage from './features/admin/AdminDashboardPage.tsx';

function App() {
  return (
    <>
      <NavBar />
      <Routes>
        <Route path="/dashboard" element={<DashboardPage />} />
        <Route path="/post-request" element={<PostRequestPage />} />
        <Route path="/search-requests" element={<SearchRequestsPage />} />
        <Route path="/post-proposal" element={<PostProposalPage />} />
        <Route path="/manage-proposals" element={<ManageProposalsPage />} />
        <Route path="/messages" element={<MessagesPage />} />
        <Route path="/profile" element={<ProfilePage />} />
        <Route path="/admin" element={<AdminDashboardPage />} />
        <Route path="*" element={<div>404 Not Found</div>} />
      </Routes>
    </>
  );
}

export default App;