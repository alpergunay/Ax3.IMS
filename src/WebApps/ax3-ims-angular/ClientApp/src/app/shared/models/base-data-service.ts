import {IAddModel} from './iadd-model';
import {IUpdateModel} from './iupdate-model';
import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseDataService {
  abstract getList();
  abstract getById(id: any);
  abstract add(addModel: IAddModel);
  abstract update(updateModel: IUpdateModel);
  abstract delete();
}
