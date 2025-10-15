// Original file: ../Courses/Protos/courses.proto

import type { User as _courses_User, User__Output as _courses_User__Output } from '../courses/User';

export interface GetCurrentUserResponse {
  'user'?: (_courses_User | null);
  '_user'?: "user";
}

export interface GetCurrentUserResponse__Output {
  'user'?: (_courses_User__Output | null);
  '_user'?: "user";
}
