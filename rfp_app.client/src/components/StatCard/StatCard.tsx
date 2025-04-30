import './StatCard.css';

interface StatCardProps {
  title: string;
  count: number;
}

const StatCard = ({ title, count }: StatCardProps) => {
  return (
    <div className="stat-card">
      <h2>{count}</h2>
      <p>{title}</p>
    </div>
  );
};

export default StatCard;
