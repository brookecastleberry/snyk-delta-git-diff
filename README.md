# snyk-delta-git-diff

## Purpose

This project is designed to **increase Snyk Delta scan speed by leveraging `git diff`** to focus Snyk scans on files changed in between commits. By doing so, you speed up evaluation during development, PR reviews, or CI/CD workflows.

---

## Running snyk-delta

`snyk-delta` can be run in two main ways, depending on your workflow and what you want to compare:

### 1. Inline Mode (Pipe from `snyk test`)

- **How it works:**  
  Run `snyk test` (with any flags you need), pipe the JSON results into `snyk-delta`.  
  This compares your `snyk test` output to the latest monitored snapshot of the base Snyk project.

- **Example:**  
  ```sh
  snyk test --all-projects --json | snyk-delta
  ```
  Or, for language-specific manifests:
  ```sh
  snyk test --file="<path-to-your-changed-manifest-or-lockfile>" --json | snyk-delta
  ```

---

### 2. Standalone Mode (Compare Two Monitored Snapshots)

- **How it works:**  
  Run `snyk-delta` directly, specifying two Snyk projects (typically across branches, forks, or orgs) by their org/project UUIDs.  
  This compares the monitored snapshots for each and shows the difference in vulnerabilities.

- **Example:**  
  ```sh
  snyk-delta --baselineOrg uuid-xxx-xxx-xxx --baselineProject uuid-xxx-xxx-xxx --currentOrg uuid-yyy-yyy-yyy --currentProject uuid-yyy-yyy-yyy
  ```

---

## Relevant Files for git diff

- Relevant files for `git diff` should be determined based on your project's language and the files detectable by Snyk.  
- Update the list of relevant files/extensions in your workflow to match the manifest or lock files appropriate for the language(s) you are scanning.  
- For a full list of supported files per language, refer to [Snyk CLI detect.ts](https://github.com/snyk/cli/blob/main/src/lib/detect.ts).

---

## Example use case for snyk-delta

- **Use case:** You have a `snyk monitor` running on your main branch and want to identify what vulnerabilities are new/removed in a PR or feature branch.

---

## Delta Standalone Mode

- **Limitations:**
    - If a file name or path has been renamed between running `snyk monitor` and running `snyk-delta` for a specific org and project, results may be unreliable or incomplete because it might fail to identify the correct project ID.
    - If you have duplicate projects in Snyk, you'll need to specify the project origin.
      - To view your projects and origins for a particular organization, use the Snyk API:

        ```sh
        curl --request GET \
          --url "https://api.snyk.io/rest/orgs/{orgId}/projects?version=2024-10-15" \
          --header "Content-Type: application/vnd.api+json" \
          --header "Authorization: token YOUR_SNYK_API_TOKEN"
        ```

      - This helps validate the correct project ID and avoid duplicate project confusion.

---

## Running GitHub Actions

After committing a change to a relevant file, you may want to run your GitHub Actions workflow manually. Adjust workflow based on your specific use case.

**Steps:**
1. Commit and push your changes.
2. Go to the "Actions" tab in GitHub.
3. Select the workflow you want to run.
4. Click "Run workflow" and choose any options or branch as needed.

This will trigger your workflow so your changes are processed immediately.

---

## snyk-delta Options & Flags

- You can pass various flags to customize behavior, including org/project selection, diff modes, file paths, etc.
- See the [snyk-delta documentation](https://github.com/snyk-tech-services/snyk-delta/blob/develop/README.md) for a full list of options.

---

## References

- [Snyk CLI Manifest Detection](https://github.com/snyk/cli/blob/main/src/lib/detect.ts)
- [snyk-delta Documentation & Flags](https://github.com/snyk-tech-services/snyk-delta/blob/develop/README.md)
- [Snyk REST API Docs](https://docs.snyk.io/api/v1/overview/introduction)

---

## Contributions

Contributions are welcome! Please open an issue or PR for suggestions, fixes, or improvements.

---
