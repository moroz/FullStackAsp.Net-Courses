<script lang="ts">
	import type { LocaleCode } from "$lib/translations";
	import { twMerge } from "tailwind-merge";

	interface Props {
		locale: LocaleCode;
		pathname: string;
		class?: string;
		full?: boolean;
	}

	const { locale, pathname, class: className, full }: Props = $props();
	const otherLocale = locale === "pl" ? "en" : "pl";
	const href = `${pathname}?lang=${otherLocale}`;
	const title = new Intl.DisplayNames(otherLocale, { type: "language" }).of(otherLocale);
</script>

<a {href} class={className} {title} data-sveltekit-reload>
	{full ? title : otherLocale}
</a>
