export interface ApplicationUser {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  profileImageUrl?: string;
  phoneNumber?: string;
  createdAt?: string;
  role?: string;
}

export interface UserProfileDto {
  id: string;
  firstName: string;
  lastName: string;
  dateOfBirth: string; // ISO format
  profilePictureUrl?: string;
  bio?: string;
  rating: number;
  numberOfCompletedServiceRequest: number;
  activeBids: number;
  streetAddress?: string;
  city?: string;
  state?: string;
  postalCode?: string;
  country?: string;
  lastLogin: string;
  accountCreated: string;
}