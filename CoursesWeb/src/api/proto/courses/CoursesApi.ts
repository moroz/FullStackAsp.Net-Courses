// Original file: ../Courses/Protos/courses.proto

import type * as grpc from '@grpc/grpc-js'
import type { MethodDefinition } from '@grpc/proto-loader'
import type { GetCurrentUserRequest as _courses_GetCurrentUserRequest, GetCurrentUserRequest__Output as _courses_GetCurrentUserRequest__Output } from '../courses/GetCurrentUserRequest';
import type { GetCurrentUserResponse as _courses_GetCurrentUserResponse, GetCurrentUserResponse__Output as _courses_GetCurrentUserResponse__Output } from '../courses/GetCurrentUserResponse';
import type { ListEventsRequest as _courses_ListEventsRequest, ListEventsRequest__Output as _courses_ListEventsRequest__Output } from '../courses/ListEventsRequest';
import type { ListEventsResponse as _courses_ListEventsResponse, ListEventsResponse__Output as _courses_ListEventsResponse__Output } from '../courses/ListEventsResponse';
import type { SignInResponse as _courses_SignInResponse, SignInResponse__Output as _courses_SignInResponse__Output } from '../courses/SignInResponse';
import type { SignInWithPasswordRequest as _courses_SignInWithPasswordRequest, SignInWithPasswordRequest__Output as _courses_SignInWithPasswordRequest__Output } from '../courses/SignInWithPasswordRequest';

export interface CoursesApiClient extends grpc.Client {
  GetCurrentUser(argument: _courses_GetCurrentUserRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  GetCurrentUser(argument: _courses_GetCurrentUserRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  GetCurrentUser(argument: _courses_GetCurrentUserRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  GetCurrentUser(argument: _courses_GetCurrentUserRequest, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  getCurrentUser(argument: _courses_GetCurrentUserRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  getCurrentUser(argument: _courses_GetCurrentUserRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  getCurrentUser(argument: _courses_GetCurrentUserRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  getCurrentUser(argument: _courses_GetCurrentUserRequest, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  
  ListEvents(argument: _courses_ListEventsRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  ListEvents(argument: _courses_ListEventsRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  ListEvents(argument: _courses_ListEventsRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  ListEvents(argument: _courses_ListEventsRequest, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  listEvents(argument: _courses_ListEventsRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  listEvents(argument: _courses_ListEventsRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  listEvents(argument: _courses_ListEventsRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  listEvents(argument: _courses_ListEventsRequest, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  
  SignInWithPassword(argument: _courses_SignInWithPasswordRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  SignInWithPassword(argument: _courses_SignInWithPasswordRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  SignInWithPassword(argument: _courses_SignInWithPasswordRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  SignInWithPassword(argument: _courses_SignInWithPasswordRequest, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  signInWithPassword(argument: _courses_SignInWithPasswordRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  signInWithPassword(argument: _courses_SignInWithPasswordRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  signInWithPassword(argument: _courses_SignInWithPasswordRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  signInWithPassword(argument: _courses_SignInWithPasswordRequest, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  
}

export interface CoursesApiHandlers extends grpc.UntypedServiceImplementation {
  GetCurrentUser: grpc.handleUnaryCall<_courses_GetCurrentUserRequest__Output, _courses_GetCurrentUserResponse>;
  
  ListEvents: grpc.handleUnaryCall<_courses_ListEventsRequest__Output, _courses_ListEventsResponse>;
  
  SignInWithPassword: grpc.handleUnaryCall<_courses_SignInWithPasswordRequest__Output, _courses_SignInResponse>;
  
}

export interface CoursesApiDefinition extends grpc.ServiceDefinition {
  GetCurrentUser: MethodDefinition<_courses_GetCurrentUserRequest, _courses_GetCurrentUserResponse, _courses_GetCurrentUserRequest__Output, _courses_GetCurrentUserResponse__Output>
  ListEvents: MethodDefinition<_courses_ListEventsRequest, _courses_ListEventsResponse, _courses_ListEventsRequest__Output, _courses_ListEventsResponse__Output>
  SignInWithPassword: MethodDefinition<_courses_SignInWithPasswordRequest, _courses_SignInResponse, _courses_SignInWithPasswordRequest__Output, _courses_SignInResponse__Output>
}
