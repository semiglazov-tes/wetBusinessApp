import {FormControl} from "@angular/forms";
export interface RegistrationForm {
  userName: FormControl<string>;
  userEmail: FormControl<string>;
  password: FormControl<string>;
}

