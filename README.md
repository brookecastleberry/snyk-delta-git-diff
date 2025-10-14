# snyk-delta-git-diff

![Snyk OSS Example](https://raw.githubusercontent.com/snyk-labs/oss-images/main/oss-example.jpg)

## Purpose

This project is designed to **increase Snyk Delta scan speed by leveraging `git diff`** to focus Snyk scans on files changed in between commits. By doing so, you speed up evaluation during development, PR reviews, or CI/CD workflows.

---

## Running snyk-delta

### Inline Mode (Pipe from `snyk test`)

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

## Relevant Files for git diff

- Relevant files for `git diff` should be determined based on your project's language and the files detectable by Snyk.  
- Update the list of relevant files/extensions in your workflow to match the manifest or lock files appropriate for the language(s) you are scanning.  
- For a list of supported files per language, refer to [Snyk CLI detect.ts](https://github.com/snyk/cli/blob/main/src/lib/detect.ts).
- See the [GitHub Actions workflow](.github/workflows/snyk_delta_with_test.yaml#L75-L76) for an example of how to filter for specific file types.

---

## Example use case for snyk-delta

- **Use case:** You have a `snyk monitor` running on your main branch and want to identify what vulnerabilities are new/removed in a PR from a feature branch.

---

## Adapting for Other Snyk Commands

While this example focuses on `snyk-delta`, the git diff approach can be adapted to run additional Snyk commands on only the changed files:

- **`snyk test`** - Run security tests only on changed manifest/lock files
- **`snyk monitor`** - Monitor only changed projects to update snapshots
- **`snyk code test`** - Run static code analysis only on changed source files
- **`snyk iac test`** - Test Infrastructure as Code files that have changed

The key is to adjust the file filtering logic to match the specific file types relevant to each Snyk command and your project structure.

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

---

