import {BaseUpdateModel} from '../base-update.model';

export interface AccountUpdateModel extends BaseUpdateModel {
  userId: string;
  storeBranchId: string;
  accountTypeId: string;
  investmentToolId: string;
  accountNo: string;
}
