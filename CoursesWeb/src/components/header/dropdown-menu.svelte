<script lang="ts">
	import { enhance } from "$app/forms";
	import type { User } from "@api/interfaces";
	import Avatar from "@components/avatar.svelte";

	interface Props {
		user: User;
	}

	const { user }: Props = $props();
</script>

<nav
	class="translate-y absolute -right-4 -bottom-1 w-60 translate-y-full rounded-sm border border-slate-300 bg-white shadow"
>
	<section>
		<div class="flex items-center gap-4 p-3">
			<Avatar {user} />
			<div>
				<span class="font-semibold">{user.givenName} {user.familyName}</span>
				<span>{user.email}</span>
			</div>
		</div>
	</section>
	<section>
		<ul>
			<li>
				<form action="/login?/signOut" method="POST" use:enhance>
					<button class="text h-10 w-full cursor-pointer transition-colors hover:bg-slate-100">
						Sign out
					</button>
				</form>
			</li>
		</ul>
	</section>
</nav>

<style>
	@reference "@/app.css";

	section {
		@apply border-b border-slate-300 last-of-type:border-b-0;
	}
</style>
