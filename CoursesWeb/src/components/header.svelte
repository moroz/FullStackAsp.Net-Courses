<script lang="ts">
	import LanguageSwitcher from "./language-switcher.svelte";
	import { type LocaleCode, t } from "$lib/translations";
	import type { User } from "@api/interfaces";
	import DropdownToggle from "./header/dropdown-toggle.svelte";
	import DropdownMenu from "./header/dropdown-menu.svelte";

	interface Props {
		locale: LocaleCode;
		pathname: string;
		user?: User | null;
	}

	const { locale, pathname, user }: Props = $props();

	let menuOpen = $state(false);
	let timeout: NodeJS.Timeout | null = null;

	function onHover() {
		menuOpen = true;
		timeout && clearTimeout(timeout);
	}

	function onMouseOut() {
		timeout = setTimeout(() => {
			menuOpen = false;
		}, 200);
	}
</script>

<header class="fixed inset-0 bottom-[unset] z-10 h-header bg-slate-100 text-black shadow">
	<div class="container mx-auto flex h-full items-center justify-between">
		<h1 class="text-4xl font-bold">
			<a href="/" class="text-primary no-underline transition-colors hover:text-primary-800">
				Homeo sapiens
			</a>
		</h1>
		<nav>
			<ul class="flex gap-1 py-4">
				<li><LanguageSwitcher {locale} {pathname} class="navbar-item h-full uppercase" /></li>
				<li><a href="/events" class="navbar-item">{$t("common.header.nav.events")}</a></li>
				<li><a href="/videos" class="navbar-item">{$t("common.header.nav.videos")}</a></li>
				<li><a href="/dashboard" class="navbar-item">{$t("common.header.nav.my_products")}</a></li>
				{#if user}
					<div
						tabindex="0"
						class="relative h-full"
						role="menubar"
						onmouseenter={onHover}
						onmouseleave={onMouseOut}
						onblur={onMouseOut}
					>
						<DropdownToggle {user} open={menuOpen} />
						{#if menuOpen}
							<DropdownMenu {user} />
						{/if}
					</div>
				{:else}
					<li>
						<a
							href="/login"
							class="ml-1 inline-flex h-full items-center justify-center rounded-sm border border-primary-900 px-4 font-semibold text-primary-900 transition-colors hover:bg-primary-100"
							>{$t("common.header.nav.sign_in")}</a
						>
					</li>
				{/if}
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

	nav :global(.navbar-item) {
		@apply inline-flex items-center rounded-sm px-3 font-semibold text-primary transition hover:bg-slate-200;
	}
</style>
