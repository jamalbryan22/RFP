import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../../api/axios';
import { fetchRequestTypes } from '../../services/serviceRequestService';
import { RequestTypeOption, ServiceRequestCreateDto } from '../../types/ServiceRequest';
import { ServiceRequestTypeMap } from '../../utils/enumMappings';
import './PostRequestPage.css';


const PostRequestPage = () => {
  const navigate = useNavigate();

  const [requestTypes, setRequestTypes] = useState<RequestTypeOption[]>([]);
  const [formData, setFormData] = useState<ServiceRequestCreateDto>({
    title: '',
    description: '',
    requestType: 'General',
    streetAddress: '',
    city: '',
    state: '',
    postalCode: '',
    country: '',
    budget: 0,
    deadline: ''
  });
  const [error, setError] = useState('');

  // 🔁 Load request types on mount
  useEffect(() => {
    const loadTypes = async () => {
      try {
        const types = await fetchRequestTypes();
        setRequestTypes(types);
      } catch {
        console.error('Failed to load request types');
      }
    };
    loadTypes();
  }, []);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    try {
const payload = {
  ...formData, 
  requestType: ServiceRequestTypeMap[formData.requestType],
  budget: parseFloat(formData.budget.toString()),
  deadline: formData.deadline ? new Date(formData.deadline).toISOString() : null
};

      await api.post('/servicerequest/', payload);
      navigate('/dashboard');
    } catch (err: any) {
      setError(err.response?.data?.message || 'Request submission failed.');
    }
  };

  return (
    <div className="post-request-form">
      <h2>Post a Service Request</h2>
      {error && <p className="error">{error}</p>}
      <form onSubmit={handleSubmit}>
        <label>
          Title
          <input name="title" placeholder="e.g. Build a company website" value={formData.title} onChange={handleChange} required />
        </label>
        <label>
          Description
          <textarea name="description" placeholder="e.g. Need a responsive site for a marketing agency..." value={formData.description} onChange={handleChange} required />
        </label>
        <label>
          Request Type
          <select name="requestType" value={formData.requestType} onChange={handleChange} required>
            {requestTypes.map((type) => (
              <option key={type.value} value={type.value}>{type.label}</option>
            ))}
          </select>
        </label>
        <label>
          Street Address
          <input name="streetAddress" placeholder="e.g. 123 Main St" value={formData.streetAddress || ''} onChange={handleChange} />
        </label>
        <label>
          City
          <input name="city" placeholder="e.g. Los Angeles" value={formData.city} onChange={handleChange} required />
        </label>
        <label>
          State
          <input name="state" placeholder="e.g. CA" value={formData.state} onChange={handleChange} required />
        </label>
        <label>
          Postal Code
          <input name="postalCode" placeholder="e.g. 90001" value={formData.postalCode} onChange={handleChange} required />
        </label>
        <label>
          Country
          <input name="country" placeholder="e.g. United States" value={formData.country} onChange={handleChange} required />
        </label>
        <label>
          Budget (USD)
          <input
            name="budget"
            type="text"
            placeholder="e.g. 1500.00"
            value={formData.budget.toString()}
            onChange={(e) => {
              const input = e.target.value;
              const parsed = parseFloat(input);
              setFormData((prev) => ({
                ...prev,
                budget: isNaN(parsed) || parsed < 0 ? 0 : parsed
              }));
            }}
            required
          />
        </label>
        <label>
          Completion Deadline
          <input name="deadline" type="date" value={formData.deadline || ''} onChange={handleChange} />
        </label>
        <button type="submit">Submit Request</button>
      </form>
    </div>
  );
};

export default PostRequestPage;