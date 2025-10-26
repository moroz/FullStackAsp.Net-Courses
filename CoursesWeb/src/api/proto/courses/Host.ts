// Original file: ../Courses/Protos/courses.proto

import type { UUID as _courses_UUID, UUID__Output as _courses_UUID__Output } from '../courses/UUID';
import type { Timestamp as _google_protobuf_Timestamp, Timestamp__Output as _google_protobuf_Timestamp__Output } from '../google/protobuf/Timestamp';

export interface Host {
  'id'?: (_courses_UUID | null);
  'salutation'?: (string);
  'givenName'?: (string);
  'familyName'?: (string);
  'createdAt'?: (_google_protobuf_Timestamp | null);
  'updatedAt'?: (_google_protobuf_Timestamp | null);
  'profilePictureUrl'?: (string);
  '_salutation'?: "salutation";
  '_profilePictureUrl'?: "profilePictureUrl";
}

export interface Host__Output {
  'id': (_courses_UUID__Output | null);
  'salutation'?: (string);
  'givenName': (string);
  'familyName': (string);
  'createdAt': (_google_protobuf_Timestamp__Output | null);
  'updatedAt': (_google_protobuf_Timestamp__Output | null);
  'profilePictureUrl'?: (string);
  '_salutation'?: "salutation";
  '_profilePictureUrl'?: "profilePictureUrl";
}
