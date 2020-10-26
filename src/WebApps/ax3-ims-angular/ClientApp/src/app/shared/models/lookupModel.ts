export interface LookupRequestModel {
  typed: string;
  id: number;
}

export interface LookupResponseModel {
  id: number;
  name: string;
}
export interface LookupResponseModelGuid {
  id: string;
  value: string;
}
