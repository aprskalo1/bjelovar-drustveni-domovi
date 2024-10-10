<script setup lang="ts">
import firebase from "firebase/compat/app";
import "firebaseui/dist/firebaseui.css";
import { onMounted } from "vue";
import { useRouter } from "vue-router";
import { useFirebaseUI } from "../firebase";
import { URLS, useAuthStore } from "../stores/auth";

const router = useRouter();
const authStore = useAuthStore();

onMounted(() => {
  const ui = useFirebaseUI();
  ui.reset();
  ui.start("#firebaseui-auth-container", {
    signInOptions: [
      {
        provider: firebase.auth.GoogleAuthProvider.PROVIDER_ID,
      },
      firebase.auth.TwitterAuthProvider.PROVIDER_ID,
      firebase.auth.GithubAuthProvider.PROVIDER_ID,
      "microsoft.com",
      "yahoo.com",
      firebase.auth.EmailAuthProvider.PROVIDER_ID,
      {
        provider: firebase.auth.PhoneAuthProvider.PROVIDER_ID,
        defaultCountry: "HR",
      },
    ],
    signInFlow: "popup",
    callbacks: {
      signInSuccessWithAuthResult: (result) => {
        loginToDOTNET(result);
        return false;
      },
    },
  });
});

async function loginToDOTNET(result: any) {
  console.log(result);
  const accessToken = result.credential.accessToken;
  const idToken = result.credential.idToken;
  console.log(`accessToken: ${accessToken}`);
  console.log(`idToken: ${idToken}`);

  const response = await authStore.axiosClient.post(URLS.FIREBASE_LOGIN_URL, {
    firebaseToken: idToken,
  });
  console.log(response);

  const tokens = response.data;
  console.log(tokens);

  router.push("/");
}
</script>

<template>
  <div id="login" class="mt-20 grid items-center overflow-auto">
    <div class="border-y-2 border-base-300 py-5 backdrop-blur-sm">
      <div id="firebaseui-auth-container" class="pt-5"></div>
    </div>
  </div>
</template>
