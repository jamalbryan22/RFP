import axios from "axios";

const api = axios.create({
   baseURL: "https://fictional-adventure-xpr7g997w62pgjq-5067.app.github.dev/api", //for codespaces
  // baseURL: "http://localhost:5067/api", //for local development
  headers: {
    "Content-Type": "application/json",
  },
});

// Automatically attach token if available
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem("rfp_app_authToken");
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    console.log(`🛰️ [Request] ${config.method?.toUpperCase()} - ${config.url}`);
    console.log("🔍 Headers:", config.headers);
    console.log("📦 Payload:", config.data);
    return config;
  },
  (error) => {
    console.error("❌ [Request Error]", error.message);
    return Promise.reject(error);
  },
);

api.interceptors.response.use(
  (response) => {
    console.log(`✅ [Response] ${response.status} - ${response.config.url}`);
    console.log("📦 Data:", response.data);
    return response;
  },
  (error) => {
    console.error(
      `❌ [Response Error] ${error.response?.status} - ${error.config.url}`,
    );
    console.error("🔍 Details:", error.response?.data);
    return Promise.reject(error);
  },
);

export default api;
