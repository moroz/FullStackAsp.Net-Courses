// Original file: ../Courses/Protos/courses.proto

import type { ErrorMessage as _courses_ErrorMessage, ErrorMessage__Output as _courses_ErrorMessage__Output } from '../courses/ErrorMessage';

export interface SignInResponse {
  'success'?: (boolean);
  'errors'?: (_courses_ErrorMessage)[];
  'accessToken'?: (Buffer | Uint8Array | string);
  '_accessToken'?: "accessToken";
}

export interface SignInResponse__Output {
  'success': (boolean);
  'errors': (_courses_ErrorMessage__Output)[];
  'accessToken'?: (Buffer);
  '_accessToken'?: "accessToken";
}
