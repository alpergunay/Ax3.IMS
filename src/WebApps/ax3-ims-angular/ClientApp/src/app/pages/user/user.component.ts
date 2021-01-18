import {ChangeDetectorRef, Component, OnInit, ViewChild} from '@angular/core';
import {UserModel} from "../../shared/models/user.model";
import {UserService} from "./user.service";
import {NotifyService} from "../../shared/base/notify.service";
import {SecurityService} from "../../shared/services/security.service";
import {CountryLookupComponent} from "../../shared/components/country/country-lookup/country-lookup.component";
import {CurrencyLookupComponent} from "../../shared/components/currency/currency-lookup/currency-lookup.component";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
  dataModel = <UserModel>{};
  @ViewChild(CountryLookupComponent, { static: false }) countryLookup: CountryLookupComponent;
  @ViewChild(CurrencyLookupComponent, { static: false }) currencyLookup: CurrencyLookupComponent;
  constructor(private userService: UserService,
              private notifyService: NotifyService,
              private ref: ChangeDetectorRef,
              private securityService: SecurityService) {
  }

  ngOnInit(): void {
    this.getUserCountryAndCurrencyInformation();

  }

  getUserCountryAndCurrencyInformation() {
    this.userService.getById(this.securityService.UserData.sub).subscribe(result => {
      if (result !== undefined) {
        this.dataModel = result;
        this.countryLookup.selectedText = this.dataModel.countryName;
        this.countryLookup.selectedValue = this.dataModel.countryId;
        this.countryLookup.loadData();
        this.currencyLookup.selectedText = this.dataModel.localCurrencyName;
        this.currencyLookup.selectedValue = this.dataModel.localCurrencyId;
        this.currencyLookup.loadData();
        this.ref.detectChanges();
      }
    });
  }

  validateUpdateModel(): string[] {
    const errorList = [];
    if (this.dataModel.localCurrencyId === undefined) {
      errorList.push('Kullanıcı Para Birimi Boş Bırakılamaz !');
    }
    if (this.dataModel.countryId === undefined) {
      errorList.push('Kullanıcı Ülke Seçimi Boş Bırakılamaz !');
    }
    return errorList;
  }

  clearClicked() {
    this.clearControls();
  }

  clearControls() {

  }

  saveClicked() {
    const errorList = this.validateUpdateModel();
    if (errorList != null && errorList.length === 0) {
      this.dataModel.id = this.securityService.UserData.sub;
      this.userService.update(this.dataModel).subscribe(result => {
        this.notifyService.success('Kayıt başarılı bir şekilde güncellendi');
        this.clearControls();
        this.ref.detectChanges();
      })
    } else {
      this.notifyService.error(errorList);
    }
  }
}
