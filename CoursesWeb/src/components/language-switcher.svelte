<script lang="ts">
	import type { LocaleCode } from "$lib/translations";

	interface Props {
		locale: LocaleCode;
		pathname: string;
		class?: string;
	}

	const { locale, pathname, class: className }: Props = $props();
	const otherLocale = locale === "pl" ? "en" : "pl";
	const href = `${pathname}?lang=${otherLocale}`;
	const title = new Intl.DisplayNames(otherLocale, { type: "language" }).of(otherLocale);
</script>

<a {href} class={["h-full uppercase", className]} {title} data-sveltekit-reload>
	{otherLocale}
</a>
