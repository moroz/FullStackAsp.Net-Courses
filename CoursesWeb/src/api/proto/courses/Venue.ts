// Original file: ../Courses/Protos/courses.proto

import type { UUID as _courses_UUID, UUID__Output as _courses_UUID__Output } from '../courses/UUID';
import type { Timestamp as _google_protobuf_Timestamp, Timestamp__Output as _google_protobuf_Timestamp__Output } from '../google/protobuf/Timestamp';

export interface Venue {
  'id'?: (_courses_UUID | null);
  'nameEn'?: (string);
  'namePl'?: (string);
  'street'?: (string);
  'cityEn'?: (string);
  'cityPl'?: (string);
  'postalCode'?: (string);
  'countryCode'?: (string);
  'createdAt'?: (_google_protobuf_Timestamp | null);
  'updatedAt'?: (_google_protobuf_Timestamp | null);
  '_namePl'?: "namePl";
  '_cityPl'?: "cityPl";
  '_postalCode'?: "postalCode";
}

export interface Venue__Output {
  'id': (_courses_UUID__Output | null);
  'nameEn': (string);
  'namePl'?: (string);
  'street': (string);
  'cityEn': (string);
  'cityPl'?: (string);
  'postalCode'?: (string);
  'countryCode': (string);
  'createdAt': (_google_protobuf_Timestamp__Output | null);
  'updatedAt': (_google_protobuf_Timestamp__Output | null);
  '_namePl'?: "namePl";
  '_cityPl'?: "cityPl";
  '_postalCode'?: "postalCode";
}
