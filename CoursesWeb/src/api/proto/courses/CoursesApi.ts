// Original file: ../Courses/Protos/courses.proto

import type * as grpc from '@grpc/grpc-js'
import type { MethodDefinition } from '@grpc/proto-loader'
import type { EmptyRequest as _courses_EmptyRequest, EmptyRequest__Output as _courses_EmptyRequest__Output } from '../courses/EmptyRequest';
import type { GetCurrentUserResponse as _courses_GetCurrentUserResponse, GetCurrentUserResponse__Output as _courses_GetCurrentUserResponse__Output } from '../courses/GetCurrentUserResponse';
import type { ListEventsRequest as _courses_ListEventsRequest, ListEventsRequest__Output as _courses_ListEventsRequest__Output } from '../courses/ListEventsRequest';
import type { ListEventsResponse as _courses_ListEventsResponse, ListEventsResponse__Output as _courses_ListEventsResponse__Output } from '../courses/ListEventsResponse';
import type { SignInResponse as _courses_SignInResponse, SignInResponse__Output as _courses_SignInResponse__Output } from '../courses/SignInResponse';
import type { SignInWithPasswordRequest as _courses_SignInWithPasswordRequest, SignInWithPasswordRequest__Output as _courses_SignInWithPasswordRequest__Output } from '../courses/SignInWithPasswordRequest';
import type { SignOutResponse as _courses_SignOutResponse, SignOutResponse__Output as _courses_SignOutResponse__Output } from '../courses/SignOutResponse';
import type { UserRegistrationRequest as _courses_UserRegistrationRequest, UserRegistrationRequest__Output as _courses_UserRegistrationRequest__Output } from '../courses/UserRegistrationRequest';
import type { UserRegistrationResponse as _courses_UserRegistrationResponse, UserRegistrationResponse__Output as _courses_UserRegistrationResponse__Output } from '../courses/UserRegistrationResponse';

export interface CoursesApiClient extends grpc.Client {
  GetCurrentUser(argument: _courses_EmptyRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  GetCurrentUser(argument: _courses_EmptyRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  GetCurrentUser(argument: _courses_EmptyRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  GetCurrentUser(argument: _courses_EmptyRequest, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  getCurrentUser(argument: _courses_EmptyRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  getCurrentUser(argument: _courses_EmptyRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  getCurrentUser(argument: _courses_EmptyRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  getCurrentUser(argument: _courses_EmptyRequest, callback: grpc.requestCallback<_courses_GetCurrentUserResponse__Output>): grpc.ClientUnaryCall;
  
  ListEvents(argument: _courses_ListEventsRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  ListEvents(argument: _courses_ListEventsRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  ListEvents(argument: _courses_ListEventsRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  ListEvents(argument: _courses_ListEventsRequest, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  listEvents(argument: _courses_ListEventsRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  listEvents(argument: _courses_ListEventsRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  listEvents(argument: _courses_ListEventsRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  listEvents(argument: _courses_ListEventsRequest, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  
  RegisterUser(argument: _courses_UserRegistrationRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_UserRegistrationResponse__Output>): grpc.ClientUnaryCall;
  RegisterUser(argument: _courses_UserRegistrationRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_UserRegistrationResponse__Output>): grpc.ClientUnaryCall;
  RegisterUser(argument: _courses_UserRegistrationRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_UserRegistrationResponse__Output>): grpc.ClientUnaryCall;
  RegisterUser(argument: _courses_UserRegistrationRequest, callback: grpc.requestCallback<_courses_UserRegistrationResponse__Output>): grpc.ClientUnaryCall;
  registerUser(argument: _courses_UserRegistrationRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_UserRegistrationResponse__Output>): grpc.ClientUnaryCall;
  registerUser(argument: _courses_UserRegistrationRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_UserRegistrationResponse__Output>): grpc.ClientUnaryCall;
  registerUser(argument: _courses_UserRegistrationRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_UserRegistrationResponse__Output>): grpc.ClientUnaryCall;
  registerUser(argument: _courses_UserRegistrationRequest, callback: grpc.requestCallback<_courses_UserRegistrationResponse__Output>): grpc.ClientUnaryCall;
  
  SignInWithPassword(argument: _courses_SignInWithPasswordRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  SignInWithPassword(argument: _courses_SignInWithPasswordRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  SignInWithPassword(argument: _courses_SignInWithPasswordRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  SignInWithPassword(argument: _courses_SignInWithPasswordRequest, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  signInWithPassword(argument: _courses_SignInWithPasswordRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  signInWithPassword(argument: _courses_SignInWithPasswordRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  signInWithPassword(argument: _courses_SignInWithPasswordRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  signInWithPassword(argument: _courses_SignInWithPasswordRequest, callback: grpc.requestCallback<_courses_SignInResponse__Output>): grpc.ClientUnaryCall;
  
  SignOut(argument: _courses_EmptyRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_SignOutResponse__Output>): grpc.ClientUnaryCall;
  SignOut(argument: _courses_EmptyRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_SignOutResponse__Output>): grpc.ClientUnaryCall;
  SignOut(argument: _courses_EmptyRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_SignOutResponse__Output>): grpc.ClientUnaryCall;
  SignOut(argument: _courses_EmptyRequest, callback: grpc.requestCallback<_courses_SignOutResponse__Output>): grpc.ClientUnaryCall;
  signOut(argument: _courses_EmptyRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_SignOutResponse__Output>): grpc.ClientUnaryCall;
  signOut(argument: _courses_EmptyRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_SignOutResponse__Output>): grpc.ClientUnaryCall;
  signOut(argument: _courses_EmptyRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_SignOutResponse__Output>): grpc.ClientUnaryCall;
  signOut(argument: _courses_EmptyRequest, callback: grpc.requestCallback<_courses_SignOutResponse__Output>): grpc.ClientUnaryCall;
  
}

export interface CoursesApiHandlers extends grpc.UntypedServiceImplementation {
  GetCurrentUser: grpc.handleUnaryCall<_courses_EmptyRequest__Output, _courses_GetCurrentUserResponse>;
  
  ListEvents: grpc.handleUnaryCall<_courses_ListEventsRequest__Output, _courses_ListEventsResponse>;
  
  RegisterUser: grpc.handleUnaryCall<_courses_UserRegistrationRequest__Output, _courses_UserRegistrationResponse>;
  
  SignInWithPassword: grpc.handleUnaryCall<_courses_SignInWithPasswordRequest__Output, _courses_SignInResponse>;
  
  SignOut: grpc.handleUnaryCall<_courses_EmptyRequest__Output, _courses_SignOutResponse>;
  
}

export interface CoursesApiDefinition extends grpc.ServiceDefinition {
  GetCurrentUser: MethodDefinition<_courses_EmptyRequest, _courses_GetCurrentUserResponse, _courses_EmptyRequest__Output, _courses_GetCurrentUserResponse__Output>
  ListEvents: MethodDefinition<_courses_ListEventsRequest, _courses_ListEventsResponse, _courses_ListEventsRequest__Output, _courses_ListEventsResponse__Output>
  RegisterUser: MethodDefinition<_courses_UserRegistrationRequest, _courses_UserRegistrationResponse, _courses_UserRegistrationRequest__Output, _courses_UserRegistrationResponse__Output>
  SignInWithPassword: MethodDefinition<_courses_SignInWithPasswordRequest, _courses_SignInResponse, _courses_SignInWithPasswordRequest__Output, _courses_SignInResponse__Output>
  SignOut: MethodDefinition<_courses_EmptyRequest, _courses_SignOutResponse, _courses_EmptyRequest__Output, _courses_SignOutResponse__Output>
}
