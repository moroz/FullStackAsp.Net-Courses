// Original file: ../Courses/Protos/courses.proto

export const EventType = {
  Seminar: 'Seminar',
  Webinar: 'Webinar',
} as const;

export type EventType =
  | 'Seminar'
  | 0
  | 'Webinar'
  | 1

export type EventType__Output = typeof EventType[keyof typeof EventType]
