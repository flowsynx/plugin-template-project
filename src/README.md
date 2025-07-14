# Math Plugin

The **Math Plugin** is a built-in, plug-and-play integration for the FlowSynx automation engine. It enables performing basic arithmetic operations (addition, subtraction, multiplication, division) within workflows, with no custom coding required.

This plugin is automatically installed by the FlowSynx engine when selected in the workflow builder. It is not intended for standalone developer usage outside the FlowSynx platform.

---

## Purpose

The Math Plugin allows FlowSynx users to:

- Add two numbers together.
- Subtract one number from another.
- Multiply two numbers.
- Divide one number by another with error handling for division by zero.

It integrates seamlessly into FlowSynx no-code/low-code workflows for numerical computations and data transformation tasks.

---

## Supported Operations

- **plus**: Adds `Number1` and `Number2` and returns the result.
- **subtract**: Subtracts `Number2` from `Number1`.
- **multiply**: Multiplies `Number1` by `Number2`.
- **divide**: Divides `Number1` by `Number2` (throws an error if dividing by zero).

---

## Input Parameters

The plugin accepts the following parameters:

- `Operation` (string): **Required.** The type of operation to perform. Supported values are `plus`, `subtract`, `multiply`, and `divide`.
- `Number1` (number): **Required.** The first operand.
- `Number2` (number): **Required.** The second operand.

### Example input

```json
{
  "Operation": "plus",
  "Number1": 10,
  "Number2": 5
}
```

---

## Operation Examples

### plus Operation

**Input Parameters:**

```json
{
  "Operation": "plus",
  "Number1": 10,
  "Number2": 5
}
```

**Output:**

```json
15
```

---

### subtract Operation

**Input Parameters:**

```json
{
  "Operation": "subtract",
  "Number1": 10,
  "Number2": 5
}
```

**Output:**

```json
5
```

---

### multiply Operation

**Input Parameters:**

```json
{
  "Operation": "multiply",
  "Number1": 10,
  "Number2": 5
}
```

**Output:**

```json
50
```

---

### divide Operation

**Input Parameters:**

```json
{
  "Operation": "divide",
  "Number1": 10,
  "Number2": 2
}
```

**Output:**

```json
5
```

**Example with division by zero:**

```json
{
  "Operation": "divide",
  "Number1": 10,
  "Number2": 0
}
```

**Output:**

```json
{
  "error": "Cannot divide by zero."
}
```

---

## Example Use Case in FlowSynx

1. Add the Math plugin to your FlowSynx workflow.
2. Set `Operation` to one of: `plus`, `subtract`, `multiply`, or `divide`.
3. Provide values for `Number1` and `Number2`.
4. Use the plugin output downstream in your workflow for calculations or decision-making.

---

## Debugging Tips

- Ensure `Number1` and `Number2` are numeric values.
- Use the `divide` operation cautiously with `Number2 = 0` to avoid runtime errors.
- For chaining multiple operations, combine this plugin with FlowSynx’s built-in workflow features.

---

## Security Notes

- No data is persisted unless explicitly configured.
- All operations run in a secure sandbox within FlowSynx.
- Only authorized platform users can view or modify configurations.

---

## License

© MyCompany. All rights reserved.