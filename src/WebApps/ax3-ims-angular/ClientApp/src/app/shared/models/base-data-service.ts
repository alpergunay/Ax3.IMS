import {BaseModel} from './base-add.model';
import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseDataService {
  abstract getList();
  abstract dxGetList();
  abstract getLookupList(typed: string, parentId?: any);
  abstract getById(id: any);
  abstract add(addModel: BaseModel);
  abstract update(updateModel: BaseModel);
  abstract delete();
}
