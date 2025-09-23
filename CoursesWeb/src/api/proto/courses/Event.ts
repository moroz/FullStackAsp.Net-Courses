// Original file: ../Courses/Protos/courses.proto

import type { UUID as _courses_UUID, UUID__Output as _courses_UUID__Output } from '../courses/UUID';
import type { StringValue as _google_protobuf_StringValue, StringValue__Output as _google_protobuf_StringValue__Output } from '../google/protobuf/StringValue';
import type { Timestamp as _google_protobuf_Timestamp, Timestamp__Output as _google_protobuf_Timestamp__Output } from '../google/protobuf/Timestamp';

export interface Event {
  'id'?: (_courses_UUID | null);
  'titleEn'?: (string);
  'titlePl'?: (_google_protobuf_StringValue | null);
  'startsAt'?: (_google_protobuf_Timestamp | null);
  'endsAt'?: (_google_protobuf_Timestamp | null);
  'createdAt'?: (_google_protobuf_Timestamp | null);
  'updatedAt'?: (_google_protobuf_Timestamp | null);
  'descriptionEn'?: (string);
  'descriptionPl'?: (_google_protobuf_StringValue | null);
  'isVirtual'?: (boolean);
  'venue'?: (_google_protobuf_StringValue | null);
}

export interface Event__Output {
  'id': (_courses_UUID__Output | null);
  'titleEn': (string);
  'titlePl': (_google_protobuf_StringValue__Output | null);
  'startsAt': (_google_protobuf_Timestamp__Output | null);
  'endsAt': (_google_protobuf_Timestamp__Output | null);
  'createdAt': (_google_protobuf_Timestamp__Output | null);
  'updatedAt': (_google_protobuf_Timestamp__Output | null);
  'descriptionEn': (string);
  'descriptionPl': (_google_protobuf_StringValue__Output | null);
  'isVirtual': (boolean);
  'venue': (_google_protobuf_StringValue__Output | null);
}
