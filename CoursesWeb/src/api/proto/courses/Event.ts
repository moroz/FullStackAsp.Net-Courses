// Original file: ../Courses/Protos/courses.proto

import type { UUID as _courses_UUID, UUID__Output as _courses_UUID__Output } from '../courses/UUID';
import type { StringValue as _google_protobuf_StringValue, StringValue__Output as _google_protobuf_StringValue__Output } from '../google/protobuf/StringValue';
import type { Timestamp as _google_protobuf_Timestamp, Timestamp__Output as _google_protobuf_Timestamp__Output } from '../google/protobuf/Timestamp';
import type { Host as _courses_Host, Host__Output as _courses_Host__Output } from '../courses/Host';
import type { EventType as _courses_EventType, EventType__Output as _courses_EventType__Output } from '../courses/EventType';
import type { Venue as _courses_Venue, Venue__Output as _courses_Venue__Output } from '../courses/Venue';
import type { EventPrice as _courses_EventPrice, EventPrice__Output as _courses_EventPrice__Output } from '../courses/EventPrice';
import type { Decimal as _courses_Decimal, Decimal__Output as _courses_Decimal__Output } from '../courses/Decimal';

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
  'hosts'?: (_courses_Host)[];
  'eventType'?: (_courses_EventType);
  'venue'?: (_courses_Venue | null);
  'prices'?: (_courses_EventPrice)[];
  'basePriceAmount'?: (_courses_Decimal | null);
  'basePriceCurrency'?: (_google_protobuf_StringValue | null);
  '_venue'?: "venue";
  '_basePriceAmount'?: "basePriceAmount";
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
  'hosts': (_courses_Host__Output)[];
  'eventType': (_courses_EventType__Output);
  'venue'?: (_courses_Venue__Output | null);
  'prices': (_courses_EventPrice__Output)[];
  'basePriceAmount'?: (_courses_Decimal__Output | null);
  'basePriceCurrency': (_google_protobuf_StringValue__Output | null);
  '_venue'?: "venue";
  '_basePriceAmount'?: "basePriceAmount";
}
