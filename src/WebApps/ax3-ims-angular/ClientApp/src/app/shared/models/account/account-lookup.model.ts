import {AccountModel} from "./account.model";

export interface AccountLookupModel {
  id: number;
  accountTypeName: string;
  accounts: AccountModel;
}
