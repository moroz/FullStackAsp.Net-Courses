// Original file: ../Courses/Protos/courses.proto

import type { UUID as _courses_UUID, UUID__Output as _courses_UUID__Output } from '../courses/UUID';
import type { Timestamp as _google_protobuf_Timestamp, Timestamp__Output as _google_protobuf_Timestamp__Output } from '../google/protobuf/Timestamp';

export interface User {
  'id'?: (_courses_UUID | null);
  'email'?: (string);
  'salutation'?: (string);
  'givenName'?: (string);
  'familyName'?: (string);
  'country'?: (string);
  'profession'?: (string);
  'organization'?: (string);
  'company'?: (string);
  'createdAt'?: (_google_protobuf_Timestamp | null);
  'updatedAt'?: (_google_protobuf_Timestamp | null);
  'lastLoginAt'?: (_google_protobuf_Timestamp | null);
  'lastLoginIp'?: (string);
  '_salutation'?: "salutation";
  '_country'?: "country";
  '_profession'?: "profession";
  '_organization'?: "organization";
  '_company'?: "company";
  '_lastLoginAt'?: "lastLoginAt";
  '_lastLoginIp'?: "lastLoginIp";
}

export interface User__Output {
  'id': (_courses_UUID__Output | null);
  'email': (string);
  'salutation'?: (string);
  'givenName': (string);
  'familyName': (string);
  'country'?: (string);
  'profession'?: (string);
  'organization'?: (string);
  'company'?: (string);
  'createdAt': (_google_protobuf_Timestamp__Output | null);
  'updatedAt': (_google_protobuf_Timestamp__Output | null);
  'lastLoginAt'?: (_google_protobuf_Timestamp__Output | null);
  'lastLoginIp'?: (string);
  '_salutation'?: "salutation";
  '_country'?: "country";
  '_profession'?: "profession";
  '_organization'?: "organization";
  '_company'?: "company";
  '_lastLoginAt'?: "lastLoginAt";
  '_lastLoginIp'?: "lastLoginIp";
}
