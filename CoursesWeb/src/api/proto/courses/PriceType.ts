// Original file: ../Courses/Protos/courses.proto

export const PriceType = {
  Fixed: 'Fixed',
  Percentage: 'Percentage',
  DiscountFixed: 'DiscountFixed',
  DiscountPercentage: 'DiscountPercentage',
} as const;

export type PriceType =
  | 'Fixed'
  | 0
  | 'Percentage'
  | 1
  | 'DiscountFixed'
  | 2
  | 'DiscountPercentage'
  | 3

export type PriceType__Output = typeof PriceType[keyof typeof PriceType]
