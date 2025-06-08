export interface ServiceRequestCreateDto {
  title: string;
  description: string;
  requestType: ServiceRequestType;
  streetAddress?: string;
  city: string;
  state: string;
  postalCode: string;
  country: string;
  budget: number;
  deadline?: string; // ISO string format (converted from Date)
}

export interface ServiceRequestResponseDto {
  id: number;
  title: string;
  description: string;
  requestType: string;
  status: string;
  streetAddress: string;
  city: string;
  state: string;
  postalCode: string;
  country: string;
  budget: number;
  createdAt: string;
  deadline: string;
  creatorId: string;
  creatorFullName: string;
}

export interface ServiceRequestSearchResult {
  id: number;
  title: string;
  description: string;
  requestType: string;
  streetAddress?: string;
  city: string;
  state: string;
  postalCode: string;
  country: string;
  budget: number;
  deadline?: string;
}

export interface RequestTypeOption {
  value: string;
  label: string;
}

export type ServiceRequestType =
  | "General"
  | "WebDevelopment"
  | "MobileAppDevelopment"
  | "GraphicDesign"
  | "ContentWriting"
  | "DigitalMarketing"
  | "SEO"
  | "VideoEditing"
  | "DataEntry"
  | "Consulting"
  | "SoftwareTesting"
  | "ITSupport"
  | "CyberSecurity"
  | "AI_MachineLearning"
  | "CloudServices"
  | "GameDevelopment"
  | "LegalServices"
  | "AccountingFinance"
  | "ArchitectureDesign"
  | "InteriorDesign"
  | "Translation"
  | "VirtualAssistant"
  | "Engineering"
  | "ResearchAnalysis"
  | "EcommerceSetup"
  | "BlockchainDevelopment"
  | "HomeImprovement";
