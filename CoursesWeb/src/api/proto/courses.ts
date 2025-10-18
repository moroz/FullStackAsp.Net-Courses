import type * as grpc from '@grpc/grpc-js';
import type { MessageTypeDefinition } from '@grpc/proto-loader';

import type { CoursesApiClient as _courses_CoursesApiClient, CoursesApiDefinition as _courses_CoursesApiDefinition } from './courses/CoursesApi';
import type { EmptyRequest as _courses_EmptyRequest, EmptyRequest__Output as _courses_EmptyRequest__Output } from './courses/EmptyRequest';
import type { ErrorMessage as _courses_ErrorMessage, ErrorMessage__Output as _courses_ErrorMessage__Output } from './courses/ErrorMessage';
import type { Event as _courses_Event, Event__Output as _courses_Event__Output } from './courses/Event';
import type { GetCurrentUserResponse as _courses_GetCurrentUserResponse, GetCurrentUserResponse__Output as _courses_GetCurrentUserResponse__Output } from './courses/GetCurrentUserResponse';
import type { ListEventsRequest as _courses_ListEventsRequest, ListEventsRequest__Output as _courses_ListEventsRequest__Output } from './courses/ListEventsRequest';
import type { ListEventsResponse as _courses_ListEventsResponse, ListEventsResponse__Output as _courses_ListEventsResponse__Output } from './courses/ListEventsResponse';
import type { SignInResponse as _courses_SignInResponse, SignInResponse__Output as _courses_SignInResponse__Output } from './courses/SignInResponse';
import type { SignInWithPasswordRequest as _courses_SignInWithPasswordRequest, SignInWithPasswordRequest__Output as _courses_SignInWithPasswordRequest__Output } from './courses/SignInWithPasswordRequest';
import type { SignOutResponse as _courses_SignOutResponse, SignOutResponse__Output as _courses_SignOutResponse__Output } from './courses/SignOutResponse';
import type { UUID as _courses_UUID, UUID__Output as _courses_UUID__Output } from './courses/UUID';
import type { User as _courses_User, User__Output as _courses_User__Output } from './courses/User';
import type { BoolValue as _google_protobuf_BoolValue, BoolValue__Output as _google_protobuf_BoolValue__Output } from './google/protobuf/BoolValue';
import type { BytesValue as _google_protobuf_BytesValue, BytesValue__Output as _google_protobuf_BytesValue__Output } from './google/protobuf/BytesValue';
import type { DoubleValue as _google_protobuf_DoubleValue, DoubleValue__Output as _google_protobuf_DoubleValue__Output } from './google/protobuf/DoubleValue';
import type { FloatValue as _google_protobuf_FloatValue, FloatValue__Output as _google_protobuf_FloatValue__Output } from './google/protobuf/FloatValue';
import type { Int32Value as _google_protobuf_Int32Value, Int32Value__Output as _google_protobuf_Int32Value__Output } from './google/protobuf/Int32Value';
import type { Int64Value as _google_protobuf_Int64Value, Int64Value__Output as _google_protobuf_Int64Value__Output } from './google/protobuf/Int64Value';
import type { StringValue as _google_protobuf_StringValue, StringValue__Output as _google_protobuf_StringValue__Output } from './google/protobuf/StringValue';
import type { Timestamp as _google_protobuf_Timestamp, Timestamp__Output as _google_protobuf_Timestamp__Output } from './google/protobuf/Timestamp';
import type { UInt32Value as _google_protobuf_UInt32Value, UInt32Value__Output as _google_protobuf_UInt32Value__Output } from './google/protobuf/UInt32Value';
import type { UInt64Value as _google_protobuf_UInt64Value, UInt64Value__Output as _google_protobuf_UInt64Value__Output } from './google/protobuf/UInt64Value';

type SubtypeConstructor<Constructor extends new (...args: any) => any, Subtype> = {
  new(...args: ConstructorParameters<Constructor>): Subtype;
};

export interface ProtoGrpcType {
  courses: {
    CoursesApi: SubtypeConstructor<typeof grpc.Client, _courses_CoursesApiClient> & { service: _courses_CoursesApiDefinition }
    EmptyRequest: MessageTypeDefinition<_courses_EmptyRequest, _courses_EmptyRequest__Output>
    ErrorMessage: MessageTypeDefinition<_courses_ErrorMessage, _courses_ErrorMessage__Output>
    Event: MessageTypeDefinition<_courses_Event, _courses_Event__Output>
    GetCurrentUserResponse: MessageTypeDefinition<_courses_GetCurrentUserResponse, _courses_GetCurrentUserResponse__Output>
    ListEventsRequest: MessageTypeDefinition<_courses_ListEventsRequest, _courses_ListEventsRequest__Output>
    ListEventsResponse: MessageTypeDefinition<_courses_ListEventsResponse, _courses_ListEventsResponse__Output>
    SignInResponse: MessageTypeDefinition<_courses_SignInResponse, _courses_SignInResponse__Output>
    SignInWithPasswordRequest: MessageTypeDefinition<_courses_SignInWithPasswordRequest, _courses_SignInWithPasswordRequest__Output>
    SignOutResponse: MessageTypeDefinition<_courses_SignOutResponse, _courses_SignOutResponse__Output>
    UUID: MessageTypeDefinition<_courses_UUID, _courses_UUID__Output>
    User: MessageTypeDefinition<_courses_User, _courses_User__Output>
  }
  google: {
    protobuf: {
      BoolValue: MessageTypeDefinition<_google_protobuf_BoolValue, _google_protobuf_BoolValue__Output>
      BytesValue: MessageTypeDefinition<_google_protobuf_BytesValue, _google_protobuf_BytesValue__Output>
      DoubleValue: MessageTypeDefinition<_google_protobuf_DoubleValue, _google_protobuf_DoubleValue__Output>
      FloatValue: MessageTypeDefinition<_google_protobuf_FloatValue, _google_protobuf_FloatValue__Output>
      Int32Value: MessageTypeDefinition<_google_protobuf_Int32Value, _google_protobuf_Int32Value__Output>
      Int64Value: MessageTypeDefinition<_google_protobuf_Int64Value, _google_protobuf_Int64Value__Output>
      StringValue: MessageTypeDefinition<_google_protobuf_StringValue, _google_protobuf_StringValue__Output>
      Timestamp: MessageTypeDefinition<_google_protobuf_Timestamp, _google_protobuf_Timestamp__Output>
      UInt32Value: MessageTypeDefinition<_google_protobuf_UInt32Value, _google_protobuf_UInt32Value__Output>
      UInt64Value: MessageTypeDefinition<_google_protobuf_UInt64Value, _google_protobuf_UInt64Value__Output>
    }
  }
}

