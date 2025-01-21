<script lang="ts">
    import AuthForm from "$lib/components/hairu/auth-form.svelte";
</script>

<div class="lg:p-8">
	<div class="mx-auto flex w-full flex-col justify-center space-y-6 sm:w-[350px]">
		<div class="flex flex-col space-y-2 text-center">
			<h1 class="text-2xl font-semibold tracking-tight">Welcome to Visit Enugu</h1>
			<p class="text-muted-foreground text-sm">Enter your email below to create your account</p>
		</div>
		<AuthForm/>
		<p class="text-muted-foreground px-8 text-center text-sm">
			By clicking continue, you agree to our
			<a href="/terms" class="hover:text-primary underline underline-offset-4">
				Terms of Service
			</a>
			and
			<a href="/privacy" class="hover:text-primary underline underline-offset-4">
				Privacy Policy
			</a>
			.
		</p>
	</div>
</div>
