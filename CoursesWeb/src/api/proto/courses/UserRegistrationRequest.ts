// Original file: ../Courses/Protos/courses.proto


export interface UserRegistrationRequest {
  'email'?: (string);
  'password'?: (string);
  'passwordConfirmation'?: (string);
  'givenName'?: (string);
  'familyName'?: (string);
}

export interface UserRegistrationRequest__Output {
  'email': (string);
  'password': (string);
  'passwordConfirmation': (string);
  'givenName': (string);
  'familyName': (string);
}
