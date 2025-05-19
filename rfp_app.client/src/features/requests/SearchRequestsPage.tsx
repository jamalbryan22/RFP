import { useState } from 'react';
import api from '../../api/axios';
import './SearchRequestsPage.css';
import { ServiceRequestTypeMap } from '../../utils/enumMappings';
import { ServiceRequestSearchResult} from '../../types/ServiceRequest';


const SearchRequestsPage = () => {
  const [searchTerm, setSearchTerm] = useState('');
  const [requestType, setRequestType] = useState('');
  const [city, setCity] = useState('');
  const [state, setState] = useState('');
  const [minBudget, setMinBudget] = useState('');
  const [deadline, setDeadline] = useState('');
  const [results, setResults] = useState<ServiceRequestSearchResult[]>([]);

  const handleSearch = async () => {
    try {
      const response = await api.get('/servicerequest/search', {
        params: {
          query: searchTerm,
          type: requestType,
          city,
          state,
          minBudget: minBudget ? parseFloat(minBudget) : undefined,
          deadline: deadline ? new Date(deadline).toISOString() : undefined,
        },
      });
      setResults(response.data);
    } catch (error) {
      console.error('Search failed:', error);
    }
  };

  return (
    <div className="search-requests">
      <input
        type="text"
        placeholder="Search keywords..."
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
      />
      <input
        type="text"
        placeholder="City"
        value={city}
        onChange={(e) => setCity(e.target.value)}
      />
      <input
        type="text"
        placeholder="State"
        value={state}
        onChange={(e) => setState(e.target.value)}
      />
      <input
        type="number"
        placeholder="Minimum Budget"
        value={minBudget}
        onChange={(e) => setMinBudget(e.target.value)}
      />
      <input
        type="date"
        placeholder="Deadline"
        value={deadline}
        onChange={(e) => setDeadline(e.target.value)}
      />
      <select onChange={(e) => setRequestType(e.target.value)} value={requestType}>
      <option value="">All Types</option>
      {Object.keys(ServiceRequestTypeMap).map((type) => (
        <option key={type} value={type}>
          {type.replace(/([A-Z])/g, ' $1').trim()}
        </option>
      ))}
    </select>

      <button onClick={handleSearch}>Search</button>

      <div className="search-results">
        {results.map((request) => (
          <div key={request.id} className="search-item">
            <h3>{request.title}</h3>
            <p>{request.description}</p>
            <span>{request.city}, {request.state}</span>
            <p>Budget: ${request.budget}</p>
           <p>Deadline: {request.deadline ? new Date(request.deadline).toLocaleDateString() : "No Deadline"}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default SearchRequestsPage;
