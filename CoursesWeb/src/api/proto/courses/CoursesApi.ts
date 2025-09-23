// Original file: ../Courses/Protos/courses.proto

import type * as grpc from '@grpc/grpc-js'
import type { MethodDefinition } from '@grpc/proto-loader'
import type { ListEventsRequest as _courses_ListEventsRequest, ListEventsRequest__Output as _courses_ListEventsRequest__Output } from '../courses/ListEventsRequest';
import type { ListEventsResponse as _courses_ListEventsResponse, ListEventsResponse__Output as _courses_ListEventsResponse__Output } from '../courses/ListEventsResponse';

export interface CoursesApiClient extends grpc.Client {
  ListEvents(argument: _courses_ListEventsRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  ListEvents(argument: _courses_ListEventsRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  ListEvents(argument: _courses_ListEventsRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  ListEvents(argument: _courses_ListEventsRequest, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  listEvents(argument: _courses_ListEventsRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  listEvents(argument: _courses_ListEventsRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  listEvents(argument: _courses_ListEventsRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  listEvents(argument: _courses_ListEventsRequest, callback: grpc.requestCallback<_courses_ListEventsResponse__Output>): grpc.ClientUnaryCall;
  
}

export interface CoursesApiHandlers extends grpc.UntypedServiceImplementation {
  ListEvents: grpc.handleUnaryCall<_courses_ListEventsRequest__Output, _courses_ListEventsResponse>;
  
}

export interface CoursesApiDefinition extends grpc.ServiceDefinition {
  ListEvents: MethodDefinition<_courses_ListEventsRequest, _courses_ListEventsResponse, _courses_ListEventsRequest__Output, _courses_ListEventsResponse__Output>
}
