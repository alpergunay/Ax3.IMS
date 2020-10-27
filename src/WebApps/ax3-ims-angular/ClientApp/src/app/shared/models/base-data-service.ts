import {BaseAddModel} from './base-add.model';
import {BaseUpdateModel} from './base-update.model';
import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseDataService {
  abstract getList();
  abstract getById(id: any);
  abstract add(addModel: BaseAddModel);
  abstract update(updateModel: BaseUpdateModel);
  abstract delete();
}
