import {BaseModel} from '../base-add.model';

export interface AccountAddModel extends BaseModel {
  accountNo: string;
  accountName: string;
  userId: string;
  storeBranchId: string;
  accountTypeId: number;
  accountTypeName: string;
  investmentToolId: string;
}
