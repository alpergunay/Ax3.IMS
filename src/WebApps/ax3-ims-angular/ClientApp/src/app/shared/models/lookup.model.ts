export interface LookupRequestModel {
  typed: string;
  id: any;
}

export interface AccountLookupRequestModel extends LookupRequestModel {
  investmentToolId: string;
}

export interface LookupResponseModel {
  id: any;
  name: string;
}
export interface LookupResponseModelGuid {
  id: string;
  value: string;
}
