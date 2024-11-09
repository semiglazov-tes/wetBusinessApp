import {FormControl} from "@angular/forms";
export interface LoginForm {
  UserName: FormControl<string>;
  Password: FormControl<string>;
}
