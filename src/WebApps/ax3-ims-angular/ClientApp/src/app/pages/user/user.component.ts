import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {UserModel} from "../../shared/models/user.model";
import {UserService} from "./user.service";
import {NotifyService} from "../../shared/base/notify.service";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
  dataModel = <UserModel>{};
  constructor(private userService: UserService,
              private notifyService: NotifyService,
              private ref: ChangeDetectorRef) { }

  ngOnInit(): void {
  }
  validateUpdateModel(): string[]
  {
    const errorList = [];
    return errorList;
  }
  clearClicked() {
    this.clearControls();
  }
  clearControls(){

  }
  saveClicked() {
    const errorList = this.validateUpdateModel();
    if (errorList != null && errorList.length === 0) {
      this.userService.update(this.dataModel).subscribe(result => {
        if(result == true) {
          this.notifyService.success('Kayıt başarılı bir şekilde güncellendi');
          this.clearControls();
          this.ref.detectChanges();
        }
        else {
          errorList.push('Kayıt güncellenirken bir hata meydana geldi.');
          this.notifyService.error(errorList);
        }
      });
    } else {
      this.notifyService.error(errorList);
    }
  }

}
