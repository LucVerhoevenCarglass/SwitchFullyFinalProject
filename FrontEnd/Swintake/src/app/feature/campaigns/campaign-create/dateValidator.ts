import {Injectable} from "@angular/core";
import {FormControl} from "@angular/forms";


@Injectable()
export class DateValidator {

  constructor() {
  }

  static dateBeforeToday(formdate: FormControl) {
    const today = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate(), 0, 0, 0, 0);
    const inpdate = new Date(formdate.value);
    return inpdate >= today ? null : {datecontrol:true}
  }

  static classStartDateAfterStartDate(formdate: FormControl, startdate: Date) {
    const inpdate = new Date();
    return inpdate.toDateString() >= startdate.toDateString() ? null : {datecontrol:true}
  }

}