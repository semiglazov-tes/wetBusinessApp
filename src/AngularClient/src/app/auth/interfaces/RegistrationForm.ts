import {FormControl} from "@angular/forms";
export interface RegistrationForm {
  UserName: FormControl<string>;
  Email: FormControl<string>;
  Password: FormControl<string>;
}

