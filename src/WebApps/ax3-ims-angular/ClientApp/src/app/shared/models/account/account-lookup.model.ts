import {AccountModel} from "./account.model";

export interface AccountLookupModel {
  id: number;
  // name: string;
  accountTypeName: string;
  accounts: AccountModel;
}
