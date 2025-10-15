<script lang="ts">
	import LanguageSwitcher from "./language-switcher.svelte";
	import { type LocaleCode, t } from "$lib/translations";

	interface Props {
		locale: LocaleCode;
		pathname: string;
	}

	const { locale, pathname }: Props = $props();
</script>

<header class="fixed inset-0 bottom-[unset] z-10 h-18 bg-slate-100 text-black shadow">
	<div class="container mx-auto flex h-full items-center justify-between">
		<a href="/"><h1 class="text-4xl font-bold text-primary">Homeo sapiens</h1></a>
		<nav>
			<ul class="flex">
				<li><LanguageSwitcher {locale} {pathname} /></li>
				<li><a href="/events">{$t("common.header.nav.events")}</a></li>
				<li><a href="/videos">{$t("common.header.nav.videos")}</a></li>
				<li><a href="/dashboard">{$t("common.header.nav.my_products")}</a></li>
				<li><a href="/login">Log in</a></li>
			</ul>
		</nav>
	</div>
</header>

<style>
	@reference "@/app.css";

	nav,
	ul,
	nav a {
		@apply h-full;
	}

	nav :global(a) {
		@apply inline-flex items-center px-4 text-lg font-semibold text-primary transition hover:bg-slate-200;
	}
</style>
