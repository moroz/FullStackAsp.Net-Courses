// Original file: ../Courses/Protos/courses.proto

import type { ErrorMessage as _courses_ErrorMessage, ErrorMessage__Output as _courses_ErrorMessage__Output } from '../courses/ErrorMessage';
import type { User as _courses_User, User__Output as _courses_User__Output } from '../courses/User';

export interface UserRegistrationResponse {
  'success'?: (boolean);
  'errors'?: (_courses_ErrorMessage)[];
  'user'?: (_courses_User | null);
  '_user'?: "user";
}

export interface UserRegistrationResponse__Output {
  'success': (boolean);
  'errors': (_courses_ErrorMessage__Output)[];
  'user'?: (_courses_User__Output | null);
  '_user'?: "user";
}
