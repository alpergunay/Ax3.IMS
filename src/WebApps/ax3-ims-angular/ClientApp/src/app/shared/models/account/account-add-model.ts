import {IAddModel} from '../iadd-model';

export interface AccountAddModel extends IAddModel {
  userId: string;
  storeBranchId: string;
  accountTypeId: number;
  accountTypeName: string;
  investmentToolId: string;
  accountNo: string;
}
