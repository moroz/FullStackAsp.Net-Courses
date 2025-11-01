// Original file: ../Courses/Protos/courses.proto

import type { UUID as _courses_UUID, UUID__Output as _courses_UUID__Output } from '../courses/UUID';
import type { PriceType as _courses_PriceType, PriceType__Output as _courses_PriceType__Output } from '../courses/PriceType';
import type { PriceRuleType as _courses_PriceRuleType, PriceRuleType__Output as _courses_PriceRuleType__Output } from '../courses/PriceRuleType';
import type { Decimal as _courses_Decimal, Decimal__Output as _courses_Decimal__Output } from '../courses/Decimal';
import type { Timestamp as _google_protobuf_Timestamp, Timestamp__Output as _google_protobuf_Timestamp__Output } from '../google/protobuf/Timestamp';

export interface EventPrice {
  'id'?: (_courses_UUID | null);
  'priceType'?: (_courses_PriceType);
  'ruleType'?: (_courses_PriceRuleType);
  'priceAmount'?: (_courses_Decimal | null);
  'priceCurrency'?: (string);
  'priority'?: (number);
  'isActive'?: (boolean);
  'validFrom'?: (_google_protobuf_Timestamp | null);
  'validUntil'?: (_google_protobuf_Timestamp | null);
  'createdAt'?: (_google_protobuf_Timestamp | null);
  'updatedAt'?: (_google_protobuf_Timestamp | null);
  '_validFrom'?: "validFrom";
  '_validUntil'?: "validUntil";
}

export interface EventPrice__Output {
  'id': (_courses_UUID__Output | null);
  'priceType': (_courses_PriceType__Output);
  'ruleType': (_courses_PriceRuleType__Output);
  'priceAmount': (_courses_Decimal__Output | null);
  'priceCurrency': (string);
  'priority': (number);
  'isActive': (boolean);
  'validFrom'?: (_google_protobuf_Timestamp__Output | null);
  'validUntil'?: (_google_protobuf_Timestamp__Output | null);
  'createdAt': (_google_protobuf_Timestamp__Output | null);
  'updatedAt': (_google_protobuf_Timestamp__Output | null);
  '_validFrom'?: "validFrom";
  '_validUntil'?: "validUntil";
}
