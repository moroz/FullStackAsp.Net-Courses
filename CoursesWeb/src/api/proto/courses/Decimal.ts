// Original file: ../Courses/Protos/courses.proto

import type { Long } from '@grpc/proto-loader';

export interface Decimal {
  'lo'?: (number | string | Long);
  'hi'?: (number);
  'signScale'?: (number);
  '_lo'?: "lo";
  '_hi'?: "hi";
  '_signScale'?: "signScale";
}

export interface Decimal__Output {
  'lo'?: (string);
  'hi'?: (number);
  'signScale'?: (number);
  '_lo'?: "lo";
  '_hi'?: "hi";
  '_signScale'?: "signScale";
}
