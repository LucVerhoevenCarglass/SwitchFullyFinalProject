import {Injectable} from "@angular/core";
import {FormControl} from "@angular/forms";


@Injectable()
export class DateValidator {

  constructor() {
  }
  

  static dateBeforeToday(formdate: FormControl) {
    const today = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate(), 0, 0, 0, 0);
    const inpdate = new Date(formdate.value);
    //const today = new Date();
    return inpdate > today ? null : {datecontrol:true}
//    if (formdate.value < today)  {
//        return {datecontrol:false}
//    }
//    return {datecontrol:true}

 //   const dateRegEx = new RegExp(/^\d{1,2}\.\d{1,2}\.\d{4}$/);
 //   return dateRegEx.test(formdate.value) ? null : {date: true}
  }
}