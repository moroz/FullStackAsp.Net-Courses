// Original file: ../Courses/Protos/courses.proto

export const PriceRuleType = {
  Base: 'Base',
  DiscountCode: 'DiscountCode',
  EarlyBird: 'EarlyBird',
} as const;

export type PriceRuleType =
  | 'Base'
  | 0
  | 'DiscountCode'
  | 1
  | 'EarlyBird'
  | 2

export type PriceRuleType__Output = typeof PriceRuleType[keyof typeof PriceRuleType]
