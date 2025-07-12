import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { NumericFormat } from "react-number-format";
import api from "../../api/axios";
import { AxiosError } from "axios";
import { fetchRequestTypes } from "../../services/serviceRequestService";
import {
  RequestTypeOption,
  ServiceRequestCreateDto,
} from "../../types/ServiceRequest";
import { ServiceRequestTypeMap } from "../../utils/enumMappings";
import "./PostRequestPage.css";

const PostRequestPage = () => {
  const navigate = useNavigate();

  const [requestTypes, setRequestTypes] = useState<RequestTypeOption[]>([]);
  const [formData, setFormData] = useState<ServiceRequestCreateDto>({
    title: "",
    description: "",
    requestType: "General",
    streetAddress: "",
    city: "",
    state: "",
    postalCode: "",
    country: "",
    budget: 0,
    deadline: "",
  });
  const [error, setError] = useState("");

  // 🔁 Load request types on mount
  useEffect(() => {
    const loadTypes = async () => {
      try {
        const types = await fetchRequestTypes();
        setRequestTypes(types);
      } catch {
        console.error("Failed to load request types");
      }
    };
    loadTypes();
  }, []);

  const handleChange = (
    e: React.ChangeEvent<
      HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement
    >,
  ) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError("");

    try {
      const payload = {
        ...formData,
        requestType: ServiceRequestTypeMap[formData.requestType],
        budget: parseFloat(formData.budget.toString()),
        deadline: formData.deadline
          ? new Date(formData.deadline).toISOString()
          : null,
      };

      await api.post("/servicerequest/", payload);
      navigate("/dashboard");
    } catch (err: unknown) {
      if (err instanceof AxiosError)
        setError(err.response?.data?.message || "Request submission failed.");
      else
        setError("An unexpected error occurred while submitting the request.");
    }
  };

  return (
    <div className="post-request-form">
      <h2>Post a Service Request</h2>
      {error && <p className="error">{error}</p>}
      <form onSubmit={handleSubmit}>
        <label>
          Title
          <input
            name="title"
            placeholder="e.g. Build a company website"
            value={formData.title}
            onChange={handleChange}
            required
          />
        </label>
        <label>
          Description
          <textarea
            name="description"
            placeholder="e.g. Need a responsive site for a marketing agency..."
            value={formData.description}
            onChange={handleChange}
            required
          />
        </label>
        <label>
          Request Type
          <select
            name="requestType"
            value={formData.requestType}
            onChange={handleChange}
            required
          >
            {requestTypes.map((type) => (
              <option key={type.value} value={type.value}>
                {type.label}
              </option>
            ))}
          </select>
        </label>
        <label>
          Street Address
          <input
            name="streetAddress"
            placeholder="e.g. 123 Main St"
            value={formData.streetAddress || ""}
            onChange={handleChange}
          />
        </label>
        <label>
          City
          <input
            name="city"
            placeholder="e.g. Los Angeles"
            value={formData.city}
            onChange={handleChange}
            required
          />
        </label>
        <label>
          State
          <select
            name="state"
            value={formData.state}
            onChange={handleChange}
            required
          >
            <option value="">Select a state</option>
            {[
              "AL",
              "AK",
              "AZ",
              "AR",
              "CA",
              "CO",
              "CT",
              "DC",
              "DE",
              "FL",
              "GA",
              "HI",
              "ID",
              "IL",
              "IN",
              "IA",
              "KS",
              "KY",
              "LA",
              "ME",
              "MD",
              "MA",
              "MI",
              "MN",
              "MS",
              "MO",
              "MT",
              "NE",
              "NV",
              "NH",
              "NJ",
              "NM",
              "NY",
              "NC",
              "ND",
              "OH",
              "OK",
              "OR",
              "PA",
              "RI",
              "SC",
              "SD",
              "TN",
              "TX",
              "UT",
              "VT",
              "VA",
              "WA",
              "WV",
              "WI",
              "WY",
            ].map((abbr) => (
              <option key={abbr} value={abbr}>
                {abbr}
              </option>
            ))}
          </select>
        </label>
        <label>
          Postal Code
          <input
            name="postalCode"
            placeholder="e.g. 90001"
            value={formData.postalCode}
            onChange={handleChange}
            required
          />
        </label>
        <label>
          Country
          <select
            name="country"
            value={formData.country}
            onChange={handleChange}
            required
          >
            <option value="">Select a country</option>
            <option value="United States">United States</option>
          </select>
        </label>
        <label>
          Budget (USD)
          <NumericFormat
            thousandSeparator={true}
            prefix={"$"}
            placeholder="e.g. 1,500.00"
            value={formData.budget}
            onValueChange={(values) => {
              const { floatValue } = values;
              setFormData((prev) => ({
                ...prev,
                budget: floatValue || 0,
              }));
            }}
            allowNegative={false}
            decimalScale={2}
            fixedDecimalScale={true}
            className="your-input-class" // Optional: styling
          />
        </label>
        <label>
          Completion Deadline
          <input
            name="deadline"
            type="date"
            value={formData.deadline || ""}
            onChange={handleChange}
          />
        </label>
        <button type="submit">Submit Request</button>
      </form>
    </div>
  );
};

export default PostRequestPage;
