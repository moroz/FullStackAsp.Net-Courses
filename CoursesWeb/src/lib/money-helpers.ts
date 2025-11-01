export function formatPrice(amount: string, currency: string, locale: string) {
	return new Intl.NumberFormat(locale, {
		currency,
		style: "currency",
		maximumSignificantDigits: currency === "BTC" ? 8 : 2,
	}).format(Number(amount));
}
